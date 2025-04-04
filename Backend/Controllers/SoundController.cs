namespace Backend.Controllers;

[ApiController, Route("api/soundboard")]
public sealed class SoundController : ControllerBase
{
	private readonly HttpClient httpClient;

	public SoundController()
	{
		httpClient = new HttpClient();
		httpClient.BaseAddress = new Uri("https://discord.com/api/v10/");
		httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bot", Program.Config.LoginToken);
	}

	[HttpGet, Route("available-sounds")]
	public async Task<IActionResult> AvailableSounds()
	{
		var sounds = new List<SoundboardSound>();

		foreach (var id in Program.Config.ServerIds)
		{
			var response = await httpClient.GetAsync($"guilds/{id}/soundboard-sounds");
			string json = await response.Content.ReadAsStringAsync();

			var items = JsonDocument.Parse(json).RootElement.GetProperty("items");
			sounds.AddRange(JsonSerializer.Deserialize<SoundboardSound[]>(items.GetRawText()));
		}

		return Ok(new {Sounds = sounds});
	}

	[HttpPost, Route("send-soundboard-sound")]
	public async Task<IActionResult> SendSound(SoundboardSound sound)
	{
		var soundData = new SoundPostData(sound);
		var content = new StringContent(JsonSerializer.Serialize(soundData), Encoding.UTF8, "application/json");

		try
		{
			var response = await httpClient.PostAsync($"channels/{Program.Config.DefaultVoiceChannelId}/send-soundboard-sound", content);

			if (response.IsSuccessStatusCode)
				return Ok();

			var errorMessage = await response.Content.ReadAsStringAsync();
			return StatusCode((int)response.StatusCode, new { Error = errorMessage });
		}
		catch (Exception ex)
		{
			return StatusCode(500, new { Error = ex.Message });
		}
	}

	private struct SoundPostData(SoundboardSound sound)
	{
		public string source_guild_id { get; set; } = sound.GuildId;

		public string sound_id { get; set; } = sound.Id;
	}
}