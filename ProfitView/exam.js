window.onload = LoadLessons;

async function LoadLessons() {
  const response = await fetch("https://localhost:7019/Exam/GetAll");
  const exams = await response.json();
  const tableBody = document.getElementById("exam-list");

  await exams.forEach((exam) => {
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


async function CreateExam() {
  const lessonSelect = document.getElementById('listLessons');
  const lessonCodeU = lessonSelect.options[lessonSelect.selectedIndex];
  const lessonId = lessonCodeU.getAttribute('data-id');
  const lessonCode = lessonCodeU.value
  const studentSelect = document.getElementById('listStudents');
  const studentNumU = studentSelect.options[studentSelect.selectedIndex];
  const studentId = studentNumU.getAttribute('data-id');
  const studentNum = studentNumU.value;
  const date = document.getElementById("dateExam").value;
  const grade = document.getElementById("gradeExam").value;
  
  const response = await fetch(`https://localhost:7019/Exam/Create?lCode=${lessonCode}&sNumber=${parseInt(studentNum)}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      lessonCode,
      number: parseInt(studentNum),
      date,
      grade,
     
    }),
  });

  if (response.ok) {
    alert("Success");
    location.reload();
    // await LoadLessons();
  } else {
    alert(response.error);
  }
}

async function  Selected() {
  const lessonSelect = document.getElementById('listStudents');
  const selectedOption = lessonSelect.options[lessonSelect.selectedIndex].value;
  console.warn(selectedOption)
}


async function fetchData() {
  try {
      const response = await fetch('https://localhost:7019/Exam/SelectList');
      const data = await response.json();

      const lessonSelect = document.getElementById('listLessons');
      data.lessons.forEach(lesson => {
          let option = document.createElement('option');
          option.value = lesson.lessonCode;
          option.textContent = lesson.name;
          option.setAttribute('data-id', lesson.id);
          lessonSelect.appendChild(option);
      });

      const studentSelect = document.getElementById('listStudents');
      data.students.forEach(student => {
          let option = document.createElement('option');
          option.value = student.number;
          option.textContent = student.name;
          option.setAttribute('data-id', student.id);
          studentSelect.appendChild(option);
      });

  } catch (error) {
      console.error("Error:", error);
  }
}

fetchData();