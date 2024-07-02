using UnityEngine;
using Fidelity.DebugTools;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class DebugCategory : DebugCategoryBase {
    public static DebugCategory DemoCategory => new DebugCategory(3, "Gameplay");
    public static DebugCategory General => new DebugCategory(1, "General");

    private DebugCategory(int id, string name) : base(id, name) {
    }
}

public enum DropdownEnum {
    Option1,
    Option2,
    Option3
}

public class DebugToolsSetup : MonoBehaviour {

    [SerializeField]
    private DebugSettings debugSettings;
    private DebugSlider debugSlider;
    private PaddleMovement paddleMovement;
    private List<DebugCategoryBase> extraCategories = new() {
        DebugCategory.General,
        DebugCategory.DemoCategory
    };
    private DebugTools debugTools;

    private void Awake() {
        debugTools = new DebugTools();
        debugTools.InitializeDebugMenu(debugSettings, DebugMenuMode.FlatScreen, extraCategories, transform);
        CreateLocalDebugMenu();
    }

    private void CreateLocalDebugMenu() {

        debugTools.debugMenu.AddCommand("HideDebugMenu", () => { debugTools.toggleDebugMenu?.Invoke(); }, DebugCategory.General, 0);
        debugTools.debugMenu.AddCommand("ToggleLoggerView", () => { debugTools.toggleLoggerMenu?.Invoke(); }, DebugCategory.General, 0);
        debugTools.debugMenu.AddCommand("ToggleConsoleView", () => { debugTools.toggleConsoleMenu?.Invoke(); }, DebugCategory.General, 0);

        debugTools.debugMenu.AddCommand("LogError", () => { Debug.LogError("This is an Error"); }, DebugCategory.General, 0);
        debugTools.debugMenu.AddCommand("LogWarning", () => { Debug.LogWarning("This is a Warning"); }, DebugCategory.General, 0);
        debugTools.debugMenu.AddCommand<DebugSlider>("PaddleSpeed", debugSlider.slider.value => { paddleMovement.speed = value; }, SliderElement, 0);

        // add a dropdown standard enum
        debugTools.debugMenu.AddCommand<DropdownEnum>("DropdownTest", value => Debug.Log(value), DebugCategory.General, new EnumDropDown(typeof(DropdownEnum)));

        // add console command
        debugTools.debugConsole.AddCommand("TestCommand", () => { Debug.Log("Test Command Executed"); }, "Test Command Help Test");
    }

    void Update() {
        debugTools.Tick();
    }

    private void OnDestroy() {
        debugTools.Dispose();
    }
}
