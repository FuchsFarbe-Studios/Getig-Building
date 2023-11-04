using Getig.Models.Lang;
using Getig.Services.Language;
public class LanguageService
{
    private IRepository<ConLang> _langRepo;

    public LanguageService(IRepository<ConLang> langRepo)
    {
        _langRepo = langRepo;
    }
}
