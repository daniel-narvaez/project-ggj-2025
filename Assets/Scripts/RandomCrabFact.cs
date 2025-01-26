using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class RandomCrabFact : MonoBehaviour
{
    
    private TextMeshProUGUI textMesh;

    [SerializeField] private List<string> randomCrabFacts;

    void Start()
    {
      textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public string GetRandomCrabFact() => randomCrabFacts[Random.Range(0, randomCrabFacts.Count)];

    
}
