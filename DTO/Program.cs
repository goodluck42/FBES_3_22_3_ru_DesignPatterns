var response = new TmdbMovie()
{
    PosterPath = "https://..."
};

var movie = new Movie()
{
    Poster = response.PosterPath
};


class User
{
    public int Id { get; set; }
    public string? Login { get; set; }
    public string? PasswordHash { get; set; }
    public string? SecureKey { get; set; }
    public string? DataHash { get; set; }
    public DateTime LastLogin { get; set; }
}

class UserDTO
{
    public string? Login { get; set; }
    public DateTime LastLogin { get; set; }
}


class OmdbMovie
{
    public string? Poster { get; set; }
}

class TmdbMovie
{
    public string? PosterPath { get; set; }
}


class Movie
{
    public string? Poster { get; set; }
    
}