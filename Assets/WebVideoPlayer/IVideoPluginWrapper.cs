using System;

namespace Video.Plugin
{
    public interface IVideoPluginWrapper
    {
        void Create(string id, string url, bool useHls);
        void Remove(string id);
        void TextureUpdate(string id);
        int GetTexture(string id);
        void Play(string id, float startTime);
        void Pause(string id);
        void SetVolume(string id, float volume);
        int GetHeight(string id);
        int GetWidth(string id);
        float GetTime(string id);
        float GetDuration(string id);
        int GetState(string id);
        string GetError(string id);
        void SetTime(string id, float second);
        void SetPlaybackRate(string id, float playbackRate);
        void SetLoop(string id, bool loop);
    }
}