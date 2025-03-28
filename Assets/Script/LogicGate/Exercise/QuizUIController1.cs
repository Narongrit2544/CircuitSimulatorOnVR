using UnityEngine;
using TMPro;

public class QuizUIController1 : MonoBehaviour
{
    [Header("อ้างอิงไปยัง QuizManager1")]
    public QuizManager1 quizManager;

    [Header("ตำแหน่ง TMP_Text ที่อยู่ใน Content ของ ScrollView")]
    public TMP_Text tasksScrollText;
    // ให้เตรียม TextMeshPro (TMP_Text) ไว้ใน Content ของ ScrollView แล้วลากมาใส่ช่องนี้

    [Header("Text แสดงผลลัพธ์ (อยู่นอก ScrollView)")]
    public TMP_Text resultText;

    private void Start()
    {
        if (quizManager != null && resultText != null)
        {
            quizManager.resultText = resultText;
        }

        UpdateTasksDescription();
    }


    // ฟังก์ชันสร้างข้อความรวมของโจทย์ทุกข้อ แล้วใส่ใน tasksScrollText
    private void UpdateTasksDescription()
    {
        if (quizManager == null || quizManager.tasks == null || quizManager.tasks.Count == 0)
        {
            if (tasksScrollText != null)
                tasksScrollText.text = "ไม่มีโจทย์ใน QuizManager1";
            return;
        }

        string allTasks = "";
        for (int i = 0; i < quizManager.tasks.Count; i++)
        {
            // ดึงค่า description จากแต่ละ Task
            var task = quizManager.tasks[i];
            allTasks += $"ข้อที่ {i + 1}: {task.description}\n";
        }

        if (tasksScrollText != null)
        {
            tasksScrollText.text = allTasks;
        }
    }

    // เรียกเมื่อผู้ใช้กดปุ่ม (หรือ Event อื่น) เพื่อตรวจสอบโจทย์
    public void CheckAllTasksAndShowResult()
    {
        if (quizManager == null) return;

        // สั่ง QuizManager1 ตรวจโจทย์ทั้งหมด
        quizManager.CheckAllTasks();

        // แสดงผลลัพธ์คะแนน หรือสรุปผล
        if (resultText != null)
        {
            resultText.text = quizManager.resultMessage;
        }
    }

    public void SubmitAllTasksAndShowResult()
    {
        if (quizManager == null) return;

        // สั่ง QuizManager1 ตรวจโจทย์ทั้งหมด
        quizManager.SubmitScore();

        // แสดงผลลัพธ์คะแนน หรือสรุปผล
        if (resultText != null)
        {
            resultText.text = quizManager.resultMessage;
            resultText.text = "บันทึกคะแนนสำเร็จ";
        }
    }
}
