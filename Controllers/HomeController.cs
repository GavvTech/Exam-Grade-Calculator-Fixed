using Microsoft.AspNetCore.Mvc;

namespace ExamGradeCalculator.Controllers
{
    public class CalcController : Controller
    {
        [HttpGet("/")]
        [HttpGet("/index.html")]
        public IActionResult Index()
        {
            return File("index.html", "text/html");
        }

        [HttpPost("/calculate")]
        public IActionResult Calculate(int score)
        {
            string grade = "", message = "", status = "";

            if (score < 0 || score > 50)
            {
                grade = "Invalid";
                message = "Score must be 0-50";
                status = "error";
            }
            else
            {
                // Calculate base grade using formula: 1.0 + ((50-score) * 0.1)
                double baseGrade = 1.0 + (50.0 - score) * 0.1;

                // Round to 1 decimal place
                grade = Math.Round(baseGrade, 1).ToString("F1");

                // Cap at 5.0 for scores 0-9
                if (score <= 9)
                {
                    grade = "5.0";
                }

                // Determine pass/fail status
                status = score >= 30 ? "passed" : "failed";
                message = status == "passed" ? "Passed" : "Failed";

                // For perfect score
                if (score == 50)
                {
                    message = "Perfect Grade";
                }
            }

            // FIXED HTML with status class
            var resultHtml = $@"
<!DOCTYPE html>
<html>
<head>
    <title>Exam Grade Calculator</title>
    <link rel='stylesheet' href='/css/style.css'>
</head>
<body>
    <div class='container'>
        <h1>Exam Grade Calculator</h1>
        <form method='post' action='/calculate'>
            <div class='input-group'>
                <label for='score'>Enter your exam score (0-50):</label>
                <input type='number' id='score' name='score' min='0' max='50' 
                       placeholder='0-50' required autocomplete='off' />
            </div>
            <button type='submit' class='btn'>Calculate Grade</button>
        </form>
        
        <div class='result {status}'>
            <div>
                <div style='font-size: 3em; margin-bottom: 10px;'>{grade}</div>
                <div style='font-size: 1.2em;'>Score: {score}/50</div>
                <div style='font-size: 1.1em; margin-top: 10px;'>{message}</div>
            </div>
        </div>
        
        <div class='score-range'>
            <strong>Scale:</strong> 1.0-3.0=Passed | 3.1-5.0=Failed
        </div>
    </div>
</body>
</html>";

            return Content(resultHtml, "text/html");
        }
    }
}
