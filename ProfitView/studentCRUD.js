window.onload = LoadStudents;

async function LoadStudents() {
  const response = await fetch("https://localhost:7019/Student/GetAll");
  const students = await response.json();
  const tableBody = document.getElementById("student-list");

  await students.forEach((student) => {
    let row = `<tr>
            <td>
            <button class="studentsIDs btn btn-warning">${student.id}</button>
            </td>
            <td>${student.number}</td>
            <td>${student.name} ${student.surname}</td>
            <td>${student.class}</td>
            <td><button class="removeLesson btn btn-danger">Remove</button></td>
        </tr>`;
    tableBody.innerHTML += row;
  });
}

async function CreateStudent() {
  const studentNum = document.getElementById("numberStu").value;
  const name = document.getElementById("name").value;
  const surname = document.getElementById("surname").value;
  const classNumber = document.getElementById("class").value;

  const response = await fetch("https://localhost:7019/Student/Create", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      number: parseInt(studentNum),
      name,
      surname,
      class: parseInt(classNumber),
    }),
  });

  if (response.ok) {
    alert("Success");
    location.reload();
    // await LoadLessons();
  } else {
    alert("ERROR");
  }
}

async function UpdateStudent() {
  const studentId = document.getElementById("studentIdU").value;
  const studentNum = document.getElementById("numberU").value;
  const name = document.getElementById("nameU").value;
  const surname = document.getElementById("surnameU").value;
  const classNumber = document.getElementById("classU").value;

  const response = await fetch(
    `https://localhost:7019/Student/Update?id=${studentId}`,
    {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        studentId,
        studentNum,
        name,
        surname,
        class: parseInt(classNumber),
      }),
    }
  );
  if (response.ok) {
    alert("Success");
    location.reload();
    // LoadLessons();
  } else {
    alert("ERROR");
  }
}

document
  .getElementById("student-list")
  .addEventListener("click", async function (e) {
    if (e.target.classList.contains("studentsIDs")) {

        //alert(e.target.classList);
      
        const response = await fetch(
        `https://localhost:7019/Student/UpdateView?id=${e.target.textContent}`
      );
      const student = await response.json();

      document.getElementById("studentIdU").value = student.id;
      document.getElementById("numberU").value = student.number;
      document.getElementById("nameU").value = student.name;
      document.getElementById("surnameU").value = student.surname;
      document.getElementById("classU").value = student.class;
    }
    
    if (e.target.classList.contains("removeLesson")) {
        let row = e.target.closest("tr");
        let studentId = row.querySelector(".studentsIDs").textContent.trim();
        if (confirm("Are You Sure???")) {
            await fetch(`https://localhost:7019/Student/Delete?id=${studentId}`, {
                method: "DELETE"
            });
            row.remove();
        }
    }
  });

