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

            // FIXED: Added if + proper structure
            if (score < 0 || score > 50)
            {
                grade = "❌ Invalid";
                message = "Score must be 0-50";
                status = "error";
            }
            else if (score == 50) { grade = "1.0"; message = "Perfect Grade"; status = "passed"; }
            else if (score == 49) { grade = "1.1"; message = "Passed"; status = "passed"; }
            else if (score == 48) { grade = "1.2"; message = "Passed"; status = "passed"; }
            else if (score == 47) { grade = "1.3"; message = "Passed"; status = "passed"; }
            else if (score == 46) { grade = "1.4"; message = "Passed"; status = "passed"; }
            else if (score == 45) { grade = "1.5"; message = "Passed"; status = "passed"; }
            else if (score == 44) { grade = "1.6"; message = "Passed"; status = "passed"; }
            else if (score == 43) { grade = "1.7"; message = "Passed"; status = "passed"; }
            else if (score == 42) { grade = "1.8"; message = "Passed"; status = "passed"; }
            else if (score == 41) { grade = "1.9"; message = "Passed"; status = "passed"; }
            else if (score == 40) { grade = "2.0"; message = "Passed"; status = "passed"; }
            else if (score == 39) { grade = "2.1"; message = "Passed"; status = "passed"; }
            else if (score == 38) { grade = "2.2"; message = "Passed"; status = "passed"; }
            else if (score == 37) { grade = "2.3"; message = "Passed"; status = "passed"; }
            else if (score == 36) { grade = "2.4"; message = "Passed"; status = "passed"; }
            else if (score == 35) { grade = "2.5"; message = "Passed"; status = "passed"; }
            else if (score == 34) { grade = "2.6"; message = "Passed"; status = "passed"; }
            else if (score == 33) { grade = "2.7"; message = "Passed"; status = "passed"; }
            else if (score == 32) { grade = "2.8"; message = "Passed"; status = "passed"; }
            else if (score == 31) { grade = "2.9"; message = "Passed"; status = "passed"; }
            else if (score == 30) { grade = "3.0"; message = "Passed"; status = "passed"; }
            else if (score == 29) { grade = "3.1"; message = "Failed"; status = "failed"; }
            else if (score == 28) { grade = "3.2"; message = "Failed"; status = "failed"; }
            else if (score == 27) { grade = "3.3"; message = "Failed"; status = "failed"; }
            else if (score == 26) { grade = "3.4"; message = "Failed"; status = "failed"; }
            else if (score == 25) { grade = "3.5"; message = "Failed"; status = "failed"; }
            else if (score == 24) { grade = "3.6"; message = "Failed"; status = "failed"; }
            else if (score == 23) { grade = "3.7"; message = "Failed"; status = "failed"; }
            else if (score == 22) { grade = "3.8"; message = "Failed"; status = "failed"; }
            else if (score == 21) { grade = "3.9"; message = "Failed"; status = "failed"; }
            else if (score == 20) { grade = "4.0"; message = "Failed"; status = "failed"; }
            else if (score == 19) { grade = "4.1"; message = "Failed"; status = "failed"; }
            else if (score == 18) { grade = "4.2"; message = "Failed"; status = "failed"; }
            else if (score == 17) { grade = "4.3"; message = "Failed"; status = "failed"; }
            else if (score == 16) { grade = "4.4"; message = "Failed"; status = "failed"; }
            else if (score == 15) { grade = "4.5"; message = "Failed"; status = "failed"; }
            else if (score == 14) { grade = "4.6"; message = "Failed"; status = "failed"; }
            else if (score == 13) { grade = "4.7"; message = "Failed"; status = "failed"; }
            else if (score == 12) { grade = "4.8"; message = "Failed"; status = "failed"; }
            else if (score == 11) { grade = "4.9"; message = "Failed"; status = "failed"; }
            else if (score == 10) { grade = "5.0"; message = "Failed"; status = "failed"; }
            else if (score == 9) { grade = "5.0"; message = "Failed"; status = "failed"; }
            else if (score == 9) { grade = "5.0"; message = "Failed"; status = "failed"; }
            else if (score == 7) { grade = "5.0"; message = "Failed"; status = "failed"; }
            else if (score == 6) { grade = "5.0"; message = "Failed"; status = "failed"; }
            else if (score == 5) { grade = "5.0"; message = "Failed"; status = "failed"; }
            else if (score == 4) { grade = "5.0"; message = "Failed"; status = "failed"; }
            else if (score == 3) { grade = "5.0"; message = "Failed"; status = "failed"; }
            else if (score == 2) { grade = "5.0"; message = "Failed"; status = "failed"; }
            else if (score == 1) { grade = "5.0"; message = "Failed"; status = "failed"; }
            else if (score == 0) { grade = "5.0"; message = "Failed"; status = "failed"; }

            // FIXED HTML with status class
            var resultHtml = $@"
<!DOCTYPE html>
<html>
<head>
    <title>Result - {grade}</title>
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