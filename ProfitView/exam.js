window.onload = LoadLessons;

async function LoadLessons() {
  const response = await fetch("https://localhost:7019/Exam/GetAll");
  const exams = await response.json();
  const tableBody = document.getElementById("exam-list");

  await exams.forEach((exam) => {
    let formattedDate = new Date(Date.UTC(2012, 11, 20, 3, 0, 0));
    const options = {
        weekday: "long",
        year: "numeric",
        month: "long",
        day: "numeric",
      };
    let row = `<tr>
            <td>${exam.id}</td>
            <td>${exam.lessonCode}</td>
            <td>${exam.number}</td>
            <td>${exam.date}</td>
            <td>${exam.grade}</td>
        </tr>`;
    tableBody.innerHTML += row;
  });
}
