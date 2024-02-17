namespace Desafio.Senha.Core
{
    public class AppsettingsRulesOptions
    {

        public const string AppsettingsRules = "AppsettingsRules";

        public List<Rule> Rules { get; set; }

        public class Rule
        {
            public string Description { get; set; } = string.Empty;
            public string Position { get; set; } = string.Empty;
        }

      
    }
}
