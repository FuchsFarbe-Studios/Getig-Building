using Getig.Models.Lang;
using Getig.Services.Data;
using Getig.Services.Language;
public class LanguageService
{
    private readonly GetigDbContext _ctx;
    private IRepository<ConLang> _langRepo;

    public LanguageService()
    {
        _ctx = new GetigDbContext();
        _langRepo = new Repository<ConLang>(_ctx);
    }

    public LanguageService(IRepository<ConLang> langRepo)
    {
        _langRepo = langRepo;
    }

    public async void AddLanguageAsync(ConLang lang)
    {
        await _langRepo.AddAsync(lang);
    }
}