namespace InputTextureService.TextureConfig
{
    public interface IAsyncTexturReader
    {
        Task<InputTexture> ReadTextureAsync();
    }
}
