public class RateLimiter {
    private readonly Dictionary<string, List<DateTime>> _requests = new();
    private readonly TimeSpan _period = TimeSpan.FromMinutes(1);
    private readonly int _maxRequests = 10;

    public bool isRateLimited(string userId) {
        if (!_requests.ContainsKey(userId)) {
            _requests[userId] = new List<DateTime> { DateTime.UtcNow } ;
            return false;
        }
        var now = DateTime.UtcNow;
        _requests[userId].RemoveAll(t => now - t > this._period);
        _requests[userId].Add(now);

        return _requests[userId].Count > this._maxRequests;
    }
}