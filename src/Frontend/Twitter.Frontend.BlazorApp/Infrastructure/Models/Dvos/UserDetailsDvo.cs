namespace Twitter.Frontend.BlazorApp.Infrastructure.Models.Dvos;

using System;
using System.Text.Json.Serialization;

public class UserDetailsDvo
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("createdDate")]
    public DateTime CreatedDate { get; set; }
    
    [JsonPropertyName("username")]
    public string Username { get; set; }
    
    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }
    
    [JsonPropertyName("email")]
    public string Email { get; set; }
    
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }
    
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }
    
    [JsonPropertyName("bio")]
    public string Bio { get; set; }
    
    [JsonPropertyName("location")]
    public string Location { get; set; }
    
    [JsonPropertyName("imageUrl")]
    public string ImageUrl { get; set; }
}
