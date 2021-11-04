using System.Collections;
using UnityEngine.Assertions;
using Video.Plugin;

namespace Video.Plugin
{
    public class VideoPluginWrapper_Mock : IVideoPluginWrapper
    {
        public bool isCreated = false;
        public bool isReady = false;
        public float currentTime = 0;

        private VideoState state;

        public void Create(string id, string url, bool useHls)
        {
            isCreated = true;
            CoroutineStarter.Start(ReadyWithDelay());
        }

        private IEnumerator ReadyWithDelay()
        {
            yield return null;
            yield return null;
            yield return null;
            isReady = true;
        }

        public void Remove(string id)
        {
            Assert.IsTrue(isCreated);
            isReady = false;
        }

        public void TextureUpdate(string id)
        {
            Assert.IsTrue(isCreated);
        }

        public int GetTexture(string id)
        {
            Assert.IsTrue(isCreated);
            return 0;
        }

        public void Play(string id, float startTime)
        {
            Assert.IsTrue(isCreated, "Video should be created first!");
            Assert.IsTrue(isReady, "Play never should be called if video is not ready.");
            currentTime = startTime;
        }

        public void Pause(string id)
        {
            Assert.IsTrue(isCreated, "Video should be created first!");
        }

        public void SetVolume(string id, float volume)
        {
            Assert.IsTrue(isCreated, "Video should be created first!");
        }

        public int GetHeight(string id)
        {
            Assert.IsTrue(isCreated, "Video should be created first!");
            return 250;
        }

        public int GetWidth(string id)
        {
            Assert.IsTrue(isCreated, "Video should be created first!");
            return 250;
        }

        public float GetTime(string id)
        {
            Assert.IsTrue(isCreated, "Video should be created first!");
            return currentTime;
        }

        public float GetDuration(string id)
        {
            Assert.IsTrue(isCreated, "Video should be created first!");
            return 0;
        }

        public int GetState(string id)
        {
            Assert.IsTrue(isCreated, "Video should be created first!");
            return (int)state;
        }

        public string GetError(string id)
        {
            Assert.IsTrue(isCreated, "Video should be created first!");
            return "error";
        }

        public void SetTime(string id, float second)
        {
            Assert.IsTrue(isCreated, "Video should be created first!");
        }

        public void SetPlaybackRate(string id, float playbackRate)
        {
            Assert.IsTrue(isCreated, "Video should be created first!");
        }

        public void SetLoop(string id, bool loop)
        {
            Assert.IsTrue(isCreated, "Video should be created first!");
        }
    }
}