using System.Collections.Generic;

namespace LD41.Scenes
{
    public class SceneManager
    {

        private MainGame game;

        public Scene currentScene { get; set; }
        public List<Scene> scenes = new List<Scene>();

        public SceneManager(MainGame game)
        {
            this.game = game;
        }

        public void ChangeScene(string sceneName)
        {
            for (int i = 0; i < scenes.Count; i++)
            {
                if (scenes[i].Name == sceneName)
                {
                    currentScene = scenes[i];
                    currentScene.Init();
                    return;
                }
            }
        }

        public void AddScene(Scene newScene)
        {
            scenes.Add(newScene);
        }

        public void Init()
        {
            if (currentScene != null)
            {
                currentScene.Init();
            }
        }

        public void Update()
        {
            if (currentScene != null)
            {
                currentScene.Update();
            }
        }

        public void Draw()
        {
            if (currentScene != null)
            {
                currentScene.Draw();
            }
        }

    }
}
