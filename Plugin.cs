using System.Linq;
using BepInEx;
using BepInEx.Logging;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PodcastRandomizer;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
        
    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RandomizeScenePodcasts(scene);
    }

    private void RandomizeScenePodcasts(Scene scene)
    {
        // Podcast 1 - AFJ
        if (scene.name == "Main_Section_00-01-Parkade")
        {
            var randX = Random.Range(-295f, -373f);
            var randY = Random.Range(150f, 190f);
            var randZ = Random.Range(142f, 65f);

            var podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_Events/Podcast") != null).transform.Find("c_Events/Podcast");
            podcast.transform.position = new Vector3(randX, randY, randZ);
        }

        // Podcast 2 + 3 - WW lower
        else if (scene.name == "Main_Section_03-01-Slingshots")
        {
            var rootObjects = scene.GetRootGameObjects();
    
            foreach (var root in rootObjects)
            {
                // Two podcasts with the same name
                var podcastItems = root.GetComponentsInChildren<Transform>(true)
                    .Where(t => t.name == "PodcastPickableItem")
                    .ToList();
                
                foreach (var podcast in podcastItems)
                {
                    var randX = Random.Range(-208f, -171f);
                    var randY = Random.Range(172f, 108f);
                    var randZ = Random.Range(178f, 135f);

                    podcast.transform.position = new Vector3(randX, randY, randZ);
                }
            }
        }

        // Podcast 4 - WW upper
        else if (scene.name == "Main_Section_03-03-EasyFlowJumps")
        {
            var randX = Random.Range(-222f, -145f);
            var randY = Random.Range(217f, 198f);
            var randZ = Random.Range(179f, 142f);

            var podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_level/Podcast") != null).transform.Find("c_level/Podcast");
            podcast.transform.position = new Vector3(randX, randY, randZ);
        }

        // Podcast 5 - UI lower
        else if (scene.name == "Main_Section_04-01-AirControlTutorial2")
        {
            var randX = Random.Range(-174f, -130f);
            var randY = Random.Range(241f, 251f);
            var randZ = Random.Range(130f, 168f);

            var podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_Level/Podcast-05-RealJob") != null).transform.Find("c_Level/Podcast-05-RealJob");
            podcast.transform.position = new Vector3(randX, randY, randZ);
        }

        // Podcast 6 - UI upper
        else if (scene.name == "Main_Section_05-00-4Floors")
        {
            var randX = Random.Range(-128f, -173f);
            var randY = Random.Range(274f, 295f);
            var randZ = Random.Range(163f, 104f);

            var podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_Level/Podcast_04-EyeContact") != null).transform.Find("c_Level/Podcast_04-EyeContact");
            podcast.transform.position = new Vector3(randX, randY, randZ);
        }

        // Podcast 7 + 8 - JFA
        else if (scene.name == "Main_Section_06-01-GiantWheel")
        {
            var randX = Random.Range(-173f, -68f);
            var randY = Random.Range(295f, 456f);
            var randZ = Random.Range(104f, 30f);

            var podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_level/Podcast-06-VisionBoard") != null).transform.Find("c_level/Podcast-06-VisionBoard");
            podcast.transform.position = new Vector3(randX, randY, randZ);

            randX = Random.Range(-173f, -68f);
            randY = Random.Range(295f, 456f);
            randZ = Random.Range(104f, 30f);

            podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_level/Podcast-07-CompoundInterest") != null).transform.Find("c_level/Podcast-07-CompoundInterest");
            podcast.transform.position = new Vector3(randX, randY, randZ);
        }

        // Podcast 9 - MMI
        else if (scene.name == "Main_Section_06-02-Bumpers")
        {
            var randX = Random.Range(-70f, -132f);
            var randY = Random.Range(478f, 498f);
            var randZ = Random.Range(9f, 83f);

            var podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_level/Podcast-08-DoubleTriples") != null).transform.Find("c_level/Podcast-08-DoubleTriples");
            podcast.transform.position = new Vector3(randX, randY, randZ);
        }

        // Podcast 10 + 11 + 12 - MM
        else if (scene.name == "Main_Section_07-01-BrownPyramid")
        {
            // 10 - MM lower
            var randX = Random.Range(-103f, -124f);
            var randY = Random.Range(445f, 459f);
            var randZ = Random.Range(167f, 238f);

            var podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_Level/Podcast-09_Compound") != null).transform.Find("c_Level/Podcast-09_Compound");
            podcast.transform.position = new Vector3(randX, randY, randZ);

            // 11 + 12 - MM mid
            randX = Random.Range(-168f, -124f);
            randY = Random.Range(451f, 460f);
            randZ = Random.Range(213f, 238f);

            podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_Level/Podcast-10-DeadlyNightshade") != null).transform.Find("c_Level/Podcast-10-DeadlyNightshade");
            podcast.transform.position = new Vector3(randX, randY, randZ);

            randX = Random.Range(-168f, -124f);
            randY = Random.Range(451f, 460f);
            randZ = Random.Range(213f, 238f);

            podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_Level/Podcast-11-Doubles") != null).transform.Find("c_Level/Podcast-11-Doubles");
            podcast.transform.position = new Vector3(randX, randY, randZ);
        }

        // Podcast 13 + 14 - MM upper
        else if (scene.name == "Main_Section_07-02-BrownRamp")
        {
            var randX = Random.Range(-182f, -95f);
            var randY = Random.Range(491f, 537f);
            var randZ = Random.Range(232f, 290f);

            var podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_level/Podcast-12-NewSideKick1") != null).transform.Find("c_level/Podcast-12-NewSideKick1");
            podcast.transform.position = new Vector3(randX, randY, randZ);

           randX = Random.Range(-182f, -95f);
           randY = Random.Range(491f, 537f);
           randZ = Random.Range(232f, 290f);

            podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_level/Podcast-12-NewSideKick2") != null).transform.Find("c_level/Podcast-12-NewSideKick2");
            podcast.transform.position = new Vector3(randX, randY, randZ);
        }

        // Podcast 15 + 16 + 17 + 18 - VP
        else if (scene.name == "Main_Section_08-02-TowerRight")
        {
            // 15 + 16 - VP lower
            var randX = Random.Range(-95f, -161f);
            var randY = Random.Range(597f, 678f);
            var randZ = Random.Range(352f, 313f);

            var podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_level/Podcast-14-NewYacht") != null).transform.Find("c_level/Podcast-14-NewYacht");
            podcast.transform.position = new Vector3(randX, randY, randZ);

            randX = Random.Range(-95f, -161f);
            randY = Random.Range(597f, 678f);
            randZ = Random.Range(352f, 313f);

            podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_level/Podcast-15-LargeScaleFishing") != null).transform.Find("c_level/Podcast-15-LargeScaleFishing");
            podcast.transform.position = new Vector3(randX, randY, randZ);

            // 17 + 18 - VP upper
            randX = Random.Range(-85f, -152f);
            randY = Random.Range(620f, 786f);
            randZ = Random.Range(283f, 191f);

            podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_level/Podcast-16-MultiTasking") != null).transform.Find("c_level/Podcast-16-MultiTasking");
            podcast.transform.position = new Vector3(randX, randY, randZ);

            randX = Random.Range(-85f, -152f);
            randY = Random.Range(620f, 786f);
            randZ = Random.Range(283f, 191f);

            podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_level/Podcast-17-CrediCardFraud") != null).transform.Find("c_level/Podcast-17-CrediCardFraud");
            podcast.transform.position = new Vector3(randX, randY, randZ);
        }

        // Podcast 19 - CEO
        else if (scene.name == "Main_Section_08-05-Space")
        {
            var randX = Random.Range(-80f, -167f);
            var randY = Random.Range(845f, 913f);
            var randZ = Random.Range(338f, 176f);

            var podcast = scene.GetRootGameObjects().First(x => x.transform.Find("Podcast-118-JailHacks") != null).transform.Find("Podcast-118-JailHacks");
            podcast.transform.position = new Vector3(randX, randY, randZ);
        }
    }
}
