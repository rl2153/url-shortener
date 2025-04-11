using Microsoft.EntityFrameworkCore;

public class UrlService {
    // access to db (injected database context)
    private readonly AppDbContext _context;

    public UrlService(AppDbContext context) {
        _context = context;
    }

    public async Task<string> ShortenUrl(string originalUrl, string userId) {
        var shortCode = Guid.NewGuid().ToString().Substring(0, 6);
        var mapping = new UrlMapping {
            OriginalUrl = originalUrl,
            ShortCode = shortCode,
            UserId = userId,
            CreatedAt = DateTime.UtcNow
        };

        _context.UrlMappings.Add(mapping);
        await _context.SaveChangesAsync();
        return shortCode;
    }

    public async Task<string?> GetOriginalUrl(string shortCode) {
        var mapping = await _context.UrlMappings.FirstOrDefaultAsync(m => m.ShortCode == shortCode);
        return mapping?.OriginalUrl;
    }
}
