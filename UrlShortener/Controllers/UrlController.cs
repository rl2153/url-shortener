using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/url")]
public class UrlController : ControllerBase {
    private readonly UrlService _urlService;
    private readonly RateLimiter _rateLimiter;

    public UrlController(UrlService urlService, RateLimiter rateLimiter) {
        _urlService = urlService;
        _rateLimiter = rateLimiter;
    }

    [HttpPost("shorten")]
    [Authorize]
    public async Task<IActionResult> Shorten([FromBody] string originalUrl) {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null) return Unauthorized("You must be logged in to shorten URLs.");

        if (_rateLimiter.isRateLimited(userId)) {
            return StatusCode(429, "Rate limit exceeded");
        }

        var ShortCode = await _urlService.ShortenUrl(originalUrl, userId);
        return Ok(new { shortUrl = $"https://sho.rt/{ShortCode}"});
    }

    [HttpGet("{code}")]
    public async Task<IActionResult> RedirectToOriginal(string code) {
        var originalUrl = await _urlService.GetOriginalUrl(code);
        if (originalUrl == null) return NotFound();
        return Redirect(originalUrl);
    }
}