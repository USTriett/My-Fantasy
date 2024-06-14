using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

[RequireComponent(typeof(Animator))]
public class HealthController : MonoBehaviour
{
    // Start is called before the first frame update
    public AnimationClip clip;
    PlayableGraph playableGraph;

    void Start()
    {
        playableGraph = PlayableGraph.Create();
        playableGraph.SetTimeUpdateMode(DirectorUpdateMode.GameTime);

        var playableOutput = AnimationPlayableOutput.Create(
            playableGraph,
            "Animation",
            GetComponent<Animator>()
        );

        // Wrap the clip in a playable.
        var clipPlayable = AnimationClipPlayable.Create(playableGraph, clip);

        // Connect the Playable to an output.
        playableOutput.SetSourcePlayable(clipPlayable);

        // Plays the Graph.
    }

    public void Lose()
    {
        playableGraph.Play();
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        // Destroys all Playables and PlayableOutputs created by the graph.
        playableGraph.Destroy();
    }
}
