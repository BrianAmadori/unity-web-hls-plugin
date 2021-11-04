using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Video.Plugin;

namespace DCL.Components.Video.Plugin
{
    public class VideoPluginWrapper_WebGL : IVideoPluginWrapper
    {
        public void Create(string id, string url, bool useHls) { WebVideoPlugin.WebVideoPlayerCreate(id, url, useHls); }
        public void Remove(string id) { WebVideoPlugin.WebVideoPlayerRemove(id); }
        public void TextureUpdate(string id) { WebVideoPlugin.WebVideoPlayerTextureUpdate(id); }

        public int GetTexture(string id)
        {
            return WebVideoPlugin.WebVideoPlayerTextureGet(id);
        }

        public void Play(string id, float startTime) { WebVideoPlugin.WebVideoPlayerPlay(id, startTime); }
        public void Pause(string id) { WebVideoPlugin.WebVideoPlayerPause(id); }
        public void SetVolume(string id, float volume) { WebVideoPlugin.WebVideoPlayerVolume(id, volume); }
        public int GetHeight(string id) { return WebVideoPlugin.WebVideoPlayerGetHeight(id); }
        public int GetWidth(string id) { return WebVideoPlugin.WebVideoPlayerGetWidth(id); }
        public float GetTime(string id) { return WebVideoPlugin.WebVideoPlayerGetTime(id); }
        public float GetDuration(string id) { return WebVideoPlugin.WebVideoPlayerGetDuration(id); }
        public int GetState(string id) { return WebVideoPlugin.WebVideoPlayerGetState(id); }
        public string GetError(string id) { return WebVideoPlugin.WebVideoPlayerGetError(id); }
        public void SetTime(string id, float second) { WebVideoPlugin.WebVideoPlayerSetTime(id, second); }
        public void SetPlaybackRate(string id, float playbackRate) { WebVideoPlugin.WebVideoPlayerSetPlaybackRate(id, playbackRate); }
        public void SetLoop(string id, bool loop) { WebVideoPlugin.WebVideoPlayerSetLoop(id, loop); }
    }
}