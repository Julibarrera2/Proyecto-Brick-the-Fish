using System.Collections;
using UnityEngine;
using TMPro;

public class TextArchitect
{
    private TextMeshProUGUI tmpro_ui;
    private TextMeshPro tmpro_world;

    public TMP_Text tmpro => tmpro_ui != null ? tmpro_ui : tmpro_world;

    public string currentText => tmpro.text;

    public string targetText { get; private set; } = "";
    public string preText { get; private set; } = "";

    private int preTextLenght = 0;

    public string fullTargetText => preText + targetText;

    public enum BuildMethod { instant, typewriter, fade }
    public BuildMethod buildMethod = BuildMethod.typewriter;
}
