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
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

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
            var min = new Vector3(-373f, 150f, 65f);
            var max = new Vector3(-295f, 190f, 142f);

            var randX = Random.Range(min.x, max.x);
            var randY = Random.Range(min.y, max.y);
            var randZ = Random.Range(min.z, max.z);

            var podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_Events/Podcast") != null).transform.Find("c_Events/Podcast");
            podcast.transform.position = new Vector3(randX, randY, randZ);

            SpawnCube(min, max);
        }

        // Podcast 2 + 3 - WW lower
        else if (scene.name == "Main_Section_03-01-Slingshots")
        {
            var rootObjects = scene.GetRootGameObjects();

            var min = new Vector3(-208f, 108f, 135f);
            var max = new Vector3(-171f, 172f, 178f);
    
            foreach (var root in rootObjects)
            {
                // Two podcasts with the same name
                var podcastItems = root.GetComponentsInChildren<Transform>(true)
                    .Where(t => t.name == "PodcastPickableItem")
                    .ToList();
                
                foreach (var podcast in podcastItems)
                {
                    var randX = Random.Range(min.x, max.x);
                    var randY = Random.Range(min.y, max.y);
                    var randZ = Random.Range(min.z, max.z);

                    podcast.transform.position = new Vector3(randX, randY, randZ);
                }
            }

            SpawnCube(min, max);
        }

        // Podcast 4 - WW upper
        else if (scene.name == "Main_Section_03-03-EasyFlowJumps")
        {
            var min = new Vector3(-222f, 198f, 142f);
            var max = new Vector3(-145f, 217f, 179f);

            var randX = Random.Range(min.x, max.x);
            var randY = Random.Range(min.y, max.y);
            var randZ = Random.Range(min.z, max.z);

            var podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_level/Podcast") != null).transform.Find("c_level/Podcast");
            podcast.transform.position = new Vector3(randX, randY, randZ);

            SpawnCube(min, max);
        }

        // Podcast 5 - UI lower
        else if (scene.name == "Main_Section_04-01-AirControlTutorial2")
        {
            var min = new Vector3(-174f, 241f, 130f);
            var max = new Vector3(-130f, 251f, 168f);

            var randX = Random.Range(min.x, max.x);
            var randY = Random.Range(min.y, max.y);
            var randZ = Random.Range(min.z, max.z);

            var podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_Level/Podcast-05-RealJob") != null).transform.Find("c_Level/Podcast-05-RealJob");
            podcast.transform.position = new Vector3(randX, randY, randZ);
            
            SpawnCube(min, max);
        }

        // Podcast 6 - UI upper
        else if (scene.name == "Main_Section_05-00-4Floors")
        {
            var min = new Vector3(-173f, 274f, 104f);
            var max = new Vector3(-128f, 295f, 163f);

            var randX = Random.Range(min.x, max.x);
            var randY = Random.Range(min.y, max.y);
            var randZ = Random.Range(min.z, max.z);

            var podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_Level/Podcast_04-EyeContact") != null).transform.Find("c_Level/Podcast_04-EyeContact");
            podcast.transform.position = new Vector3(randX, randY, randZ);

            SpawnCube(min, max);
        }

        // Podcast 7 + 8 - JFA
        else if (scene.name == "Main_Section_06-01-GiantWheel")
        {
            var min = new Vector3(-173f, 295f, 30f);
            var max = new Vector3(-68f, 456f, 104f);

            var randX = Random.Range(min.x, max.x);
            var randY = Random.Range(min.y, max.y);
            var randZ = Random.Range(min.z, max.z);

            var podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_level/Podcast-06-VisionBoard") != null).transform.Find("c_level/Podcast-06-VisionBoard");
            podcast.transform.position = new Vector3(randX, randY, randZ);

            randX = Random.Range(min.x, max.x);
            randY = Random.Range(min.y, max.y);
            randZ = Random.Range(min.z, max.z);

            podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_level/Podcast-07-CompoundInterest") != null).transform.Find("c_level/Podcast-07-CompoundInterest");
            podcast.transform.position = new Vector3(randX, randY, randZ);

            SpawnCube(min, max);
        }

        // Podcast 9 - MMI
        else if (scene.name == "Main_Section_06-02-Bumpers")
        {
            var min = new Vector3(-132f, 478f, 9f);
            var max = new Vector3(-70, 498f, 83f);

            var randX = Random.Range(min.x, max.x);
            var randY = Random.Range(min.y, max.y);
            var randZ = Random.Range(min.z, max.z);

            var podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_level/Podcast-08-DoubleTriples") != null).transform.Find("c_level/Podcast-08-DoubleTriples");
            podcast.transform.position = new Vector3(randX, randY, randZ);

            SpawnCube(min, max);
        }

        // Podcast 10 + 11 + 12 - MM
        else if (scene.name == "Main_Section_07-01-BrownPyramid")
        {
            // 10 - MM lower
            var min = new Vector3(-124f, 445f, 167f);
            var max = new Vector3(-103f, 459f, 238f);

            var randX = Random.Range(min.x, max.x);
            var randY = Random.Range(min.y, max.y);
            var randZ = Random.Range(min.z, max.z);

            var podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_Level/Podcast-09_Compound") != null).transform.Find("c_Level/Podcast-09_Compound");
            podcast.transform.position = new Vector3(randX, randY, randZ);

            SpawnCube(min, max);

            // 11 + 12 - MM mid
            min = new Vector3(-168f, 451f, 213f);
            max = new Vector3(-124f, 460f, 238f);

            randX = Random.Range(min.x, max.x);
            randY = Random.Range(min.y, max.y);
            randZ = Random.Range(min.z, max.z);

            podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_Level/Podcast-10-DeadlyNightshade") != null).transform.Find("c_Level/Podcast-10-DeadlyNightshade");
            podcast.transform.position = new Vector3(randX, randY, randZ);

            randX = Random.Range(min.x, max.x);
            randY = Random.Range(min.y, max.y);
            randZ = Random.Range(min.z, max.z);

            podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_Level/Podcast-11-Doubles") != null).transform.Find("c_Level/Podcast-11-Doubles");
            podcast.transform.position = new Vector3(randX, randY, randZ);

            SpawnCube(min, max);
        }

        // Podcast 13 + 14 - MM upper
        else if (scene.name == "Main_Section_07-02-BrownRamp")
        {
            var min = new Vector3(-182f, 491f, 232f);
            var max = new Vector3(-95f, 537f, 290f);

            var randX = Random.Range(min.x, max.x);
            var randY = Random.Range(min.y, max.y);
            var randZ = Random.Range(min.z, max.z);

            var podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_level/Podcast-12-NewSideKick1") != null).transform.Find("c_level/Podcast-12-NewSideKick1");
            podcast.transform.position = new Vector3(randX, randY, randZ);

            randX = Random.Range(min.x, max.x);
            randY = Random.Range(min.y, max.y);
            randZ = Random.Range(min.z, max.z);

            podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_level/Podcast-12-NewSideKick2") != null).transform.Find("c_level/Podcast-12-NewSideKick2");
            podcast.transform.position = new Vector3(randX, randY, randZ);

            SpawnCube(min, max);
        }

        // Podcast 15 + 16 + 17 + 18 - VP
        else if (scene.name == "Main_Section_08-02-TowerRight")
        {
            // 15 + 16 - VP lower
            var min = new Vector3(-161f, 597f, 313f);
            var max = new Vector3(-95f, 678f, 352f);

            var randX = Random.Range(min.x, max.x);
            var randY = Random.Range(min.y, max.y);
            var randZ = Random.Range(min.z, max.z);

            var podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_level/Podcast-14-NewYacht") != null).transform.Find("c_level/Podcast-14-NewYacht");
            podcast.transform.position = new Vector3(randX, randY, randZ);

            randX = Random.Range(min.x, max.x);
            randY = Random.Range(min.y, max.y);
            randZ = Random.Range(min.z, max.z);

            podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_level/Podcast-15-LargeScaleFishing") != null).transform.Find("c_level/Podcast-15-LargeScaleFishing");
            podcast.transform.position = new Vector3(randX, randY, randZ);

            SpawnCube(min, max);

            // 17 + 18 - VP upper
            min = new Vector3(-85f, 620f, 191f);
            max = new Vector3(-152f, 786f, 283f);

            randX = Random.Range(min.x, max.x);
            randY = Random.Range(min.y, max.y);
            randZ = Random.Range(min.z, max.z);

            podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_level/Podcast-16-MultiTasking") != null).transform.Find("c_level/Podcast-16-MultiTasking");
            podcast.transform.position = new Vector3(randX, randY, randZ);

            randX = Random.Range(min.x, max.x);
            randY = Random.Range(min.y, max.y);
            randZ = Random.Range(min.z, max.z);

            podcast = scene.GetRootGameObjects().First(x => x.transform.Find("c_level/Podcast-17-CrediCardFraud") != null).transform.Find("c_level/Podcast-17-CrediCardFraud");
            podcast.transform.position = new Vector3(randX, randY, randZ);

            SpawnCube(min, max);
        }

        // Podcast 19 - CEO
        else if (scene.name == "Main_Section_08-05-Space")
        {
            var min = new Vector3(-167f, 845f, 176f);
            var max = new Vector3(-80f, 913f, 338f);

            var randX = Random.Range(min.x, max.x);
            var randY = Random.Range(min.y, max.y);
            var randZ = Random.Range(min.z, max.z);

            var podcast = scene.GetRootGameObjects().First(x => x.transform.Find("Podcast-118-JailHacks") != null).transform.Find("Podcast-118-JailHacks");
            podcast.transform.position = new Vector3(randX, randY, randZ);

            SpawnCube(min, max);
        }
    }
    

    private void SpawnCube(Vector3 min, Vector3 max)
    {
        Vector3 position = (min + max) / 2f;
        Vector3 size = max - min;

        // Create a primitive cube
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        // Set position and scale
        cube.transform.position = position;
        cube.transform.localScale = size; //new Vector3(5f, 5f, 5f);
        
        // Set to layer 0 (default layer that camera renders)
        cube.layer = 0;
        cube.SetActive(true);
        
        // Apply URP shader and set color
        var renderer = cube.GetComponent<Renderer>();
        if (renderer != null)
        {
            // Use URP Particles/Unlit shader (works in this game)
            Shader urpShader = Shader.Find("Universal Render Pipeline/Particles/Unlit");

            Material mat = new Material(urpShader);
            mat.color = new Color(0.2f, 0.8f, 0.2f, 0.3f); // Green color

            // Enable transparency rendering
            mat.SetFloat("_Surface", 1); // 0 = Opaque, 1 = Transparent
            mat.SetFloat("_Blend", 0); // 0 = Alpha, 1 = Premultiply, 2 = Additive, 3 = Multiply
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mat.SetInt("_ZWrite", 0);
            mat.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
            mat.renderQueue = 3000; // Transparent render queue

            // Make double-sided (visible from inside)
            mat.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);

            renderer.material = mat;
        }

        var collider = cube.GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        CreateCubeEdges(cube);
    }

    private void CreateCubeEdges(GameObject cube)
    {
        // Create a child object for the wireframe edges
        GameObject edges = new GameObject("CubeEdges");
        edges.transform.parent = cube.transform;
        edges.transform.localPosition = Vector3.zero;
        edges.transform.localRotation = Quaternion.identity;
        edges.transform.localScale = Vector3.one * 1.01f; // Slightly larger to prevent z-fighting
        
        // Create line renderer for edges
        LineRenderer lineRenderer = edges.AddComponent<LineRenderer>();
        
        // Set up line renderer properties
        lineRenderer.material = new Material(Shader.Find("Universal Render Pipeline/Particles/Unlit"));
        lineRenderer.startColor = new Color(0f, 1f, 0f, 1f); // Bright green edges
        lineRenderer.endColor = new Color(0f, 1f, 0f, 1f);
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.positionCount = 24; // 12 edges, but need to draw as line strips
        lineRenderer.useWorldSpace = false;
        lineRenderer.loop = false;
        
        // Define cube edge vertices (in local space, for a 1x1x1 cube)
        float s = 0.5f; // Half size
        Vector3[] edgePoints = new Vector3[]
        {
            // Bottom square
            new Vector3(-s, -s, -s), new Vector3(s, -s, -s),
            new Vector3(s, -s, -s), new Vector3(s, -s, s),
            new Vector3(s, -s, s), new Vector3(-s, -s, s),
            new Vector3(-s, -s, s), new Vector3(-s, -s, -s),
            
            // Top square
            new Vector3(-s, s, -s), new Vector3(s, s, -s),
            new Vector3(s, s, -s), new Vector3(s, s, s),
            new Vector3(s, s, s), new Vector3(-s, s, s),
            new Vector3(-s, s, s), new Vector3(-s, s, -s),

            // Vertical edges
            new Vector3(-s, -s, -s), new Vector3(-s, s, -s),
            new Vector3(s, -s, -s), new Vector3(s, s, -s),
            new Vector3(s, -s, s), new Vector3(s, s, s),
            new Vector3(-s, -s, s), new Vector3(-s, s, s),
        };
        
        lineRenderer.SetPositions(edgePoints);
    }
}
