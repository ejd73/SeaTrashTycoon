using System.Collections;
using UnityEngine;

public class InfoDisplay : MonoBehaviour
{
    public GameObject reminderCanvas; // Canvas for reminders
    public GameObject factCanvas; // Canvas for fun facts
    public GameObject[] reminderTexts; // Array of reminder text objects
    public GameObject[] factTexts; // Array of fun fact text objects

    private int currentReminderIndex = 0; // Track which reminder to show
    private int currentFactIndex = 0; // Track which fun fact to show

    void Start()
    {
        // Ensure both canvases are initially hidden
        reminderCanvas.SetActive(false);
        factCanvas.SetActive(false);

        // Start the process when the game begins
        StartCoroutine(DisplayInfoCoroutine());
    }

    // Coroutine to handle the timing for displaying reminders and fun facts
    IEnumerator DisplayInfoCoroutine()
    {
        // Wait for 10 seconds before showing the first reminder
        yield return new WaitForSeconds(10f);

        // Show all reminders first
        while (currentReminderIndex < reminderTexts.Length)
        {
            // Show the next reminder
            ShowReminder(reminderCanvas, reminderTexts[currentReminderIndex]);
            currentReminderIndex++;

            // Wait for 5 seconds
            yield return new WaitForSeconds(5f);

            // Hide the entire reminder canvas after 5 seconds (hide all reminder texts)
            HideCanvas(reminderCanvas);

            // Wait for 15 seconds before showing the next reminder
            if (currentReminderIndex < reminderTexts.Length)
            {
                yield return new WaitForSeconds(15f);
            }
        }

        // After all reminders are shown, wait for 10 seconds before showing the first fact
        yield return new WaitForSeconds(10f);

        // Show all fun facts
        while (currentFactIndex < factTexts.Length)
        {
            // Show the next fun fact
            ShowFunFact(factCanvas, factTexts[currentFactIndex]);
            currentFactIndex++;

            // Wait for 5 seconds
            yield return new WaitForSeconds(5f);

            // Hide the entire fun fact canvas after 5 seconds (hide all fun fact texts)
            HideCanvas(factCanvas);

            // Wait for 15 seconds before showing the next fact
            if (currentFactIndex < factTexts.Length)
            {
                yield return new WaitForSeconds(15f);
            }
        }
    }

    // Show the reminder text and canvas
    void ShowReminder(GameObject canvas, GameObject reminderText)
    {
        // Ensure the canvas is visible
        canvas.SetActive(true);

        // Hide all reminder texts first, then show the current one
        HideAllTexts(reminderTexts);
        reminderText.SetActive(true); // Show specific reminder text
    }

    // Show the fun fact text and canvas
    void ShowFunFact(GameObject canvas, GameObject factText)
    {
        // Ensure the canvas is visible
        canvas.SetActive(true);

        // Hide all fun fact texts first, then show the current one
        HideAllTexts(factTexts);
        factText.SetActive(true); // Show specific fun fact text
    }

    // Hide the entire canvas (both the canvas and its child text objects)
    void HideCanvas(GameObject canvas)
    {
        canvas.SetActive(false); // Hide the entire canvas
    }

    // Hide all texts in a given array (either reminders or facts)
    void HideAllTexts(GameObject[] texts)
    {
        foreach (GameObject text in texts)
        {
            text.SetActive(false); // Hide all text objects
        }
    }
}


// using System.Collections;
// using UnityEngine;

// public class InfoDisplay : MonoBehaviour
// {
//     public GameObject reminderCanvas; // Canvas for reminders
//     public GameObject factCanvas; // Canvas for fun facts
//     public GameObject[] reminderTexts; // Array of reminder text objects
//     public GameObject[] factTexts; // Array of fact text objects

//     private int currentReminderIndex = 0; // Track which reminder to show
//     private int currentFactIndex = 0; // Track which fun fact to show

//     void Start()
//     {
//         // Ensure both canvases are initially hidden
//         reminderCanvas.SetActive(false);
//         factCanvas.SetActive(false);

//         // Start the process when the game begins
//         StartCoroutine(DisplayInfoCoroutine());
//     }

//     // Coroutine to handle the timing for displaying reminders and fun facts
//     IEnumerator DisplayInfoCoroutine()
//     {
//         // Wait for 10 seconds before showing the first reminder
//         yield return new WaitForSeconds(10f);

//         // Show all reminders first
//         while (currentReminderIndex < reminderTexts.Length)
//         {
//             // Show the next reminder
//             ShowReminder(reminderCanvas, reminderTexts[currentReminderIndex]);
//             currentReminderIndex++;

//             // Wait for 5 seconds
//             yield return new WaitForSeconds(5f);

//             // Hide the entire reminder canvas after 5 seconds
//             HideCanvas(reminderCanvas);

//             // Wait for 10 seconds before showing the next reminder
//             if (currentReminderIndex < reminderTexts.Length)
//             {
//                 yield return new WaitForSeconds(12f);
//             }
//         }

//         // After all reminders are shown, wait for 10 seconds before showing the first fact
//         yield return new WaitForSeconds(10f);

//         // Show all fun facts
//         while (currentFactIndex < factTexts.Length)
//         {
//             // Show the next fun fact
//             ShowFunFact(factCanvas, factTexts[currentFactIndex]);
//             currentFactIndex++;

//             // Wait for 5 seconds
//             yield return new WaitForSeconds(5f);

//             // Hide the entire fun fact canvas after 5 seconds
//             HideCanvas(factCanvas);

//             // Wait for 30 seconds before showing the next fact
//             if (currentFactIndex < factTexts.Length)
//             {
//                 yield return new WaitForSeconds(10f);
//             }
//         }
//     }

//     // Show the reminder text and canvas
//     void ShowReminder(GameObject canvas, GameObject reminderText)
//     {
//         canvas.SetActive(true); // Show the reminder canvas
//         reminderText.SetActive(true); // Show specific reminder text
//     }

//     // Show the fun fact text and canvas
//     void ShowFunFact(GameObject canvas, GameObject factText)
//     {
//         canvas.SetActive(true); // Show the fun fact canvas
//         factText.SetActive(true); // Show specific fun fact text
//     }

//     // Hide the entire canvas (both the canvas and its child text objects)
//     void HideCanvas(GameObject canvas)
//     {
//         canvas.SetActive(false); // Hide the entire canvas
//     }
// }
