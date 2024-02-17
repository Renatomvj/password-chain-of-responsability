using Desafio.Senha.Core;
using Desafio.Senha.Core.Constants;
using Desafio.Senha.Core.Rules;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddKeyedTransient<IPasswordRuleHandler,PasswordMustContainMinimumCharactersRule>(Constants.PasswordRules);
builder.Services.AddKeyedTransient<IPasswordRuleHandler, PasswordMustContainAtLeastOneDigitRule>(Constants.PasswordRules);
builder.Services.AddKeyedTransient<IPasswordRuleHandler, PasswordMustContainAtLeastOneCapitalLetterRule>(Constants.PasswordRules);
builder.Services.AddKeyedTransient<IPasswordRuleHandler, PasswordMustContainAtLeastOneLowercaseLetterRule>(Constants.PasswordRules);
builder.Services.AddKeyedTransient<IPasswordRuleHandler, PasswordMustContainAtLeastOneSpecialCharacter>(Constants.PasswordRules);
builder.Services.AddKeyedTransient<IPasswordRuleHandler, PasswordMustNotContainRepeatedCharacters>(Constants.PasswordRules);

builder.Services.AddSingleton<PasswordRuleChainFactory>();
builder.Services.AddScoped<IPasswordValidator, PasswordValidator>();
builder.Services.AddScoped<IPasswordService, PasswordService>();

builder.Services.Configure<AppsettingsRulesOptions>(builder.Configuration.GetSection(AppsettingsRulesOptions.AppsettingsRules));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
