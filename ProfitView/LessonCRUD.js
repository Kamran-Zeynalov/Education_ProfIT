window.onload = LoadLessons;

async function LoadLessons() {
  const response = await fetch("https://localhost:7019/Lesson/GetAll");
  const lessons = await response.json();
  const tableBody = document.getElementById("lesson-list");

  await lessons.forEach((lesson) => {
    let row = `<tr>
            <td>
            <button class="lessonsIDs btn btn-warning">${lesson.id}</button>
            </td>
            <td>${lesson.lessonCode}</td>
            <td>${lesson.name}</td>
            <td>${lesson.class}</td>
            <td>${lesson.teacherName} ${lesson.teacherSurname}</td>
            <td><button class="removeLesson btn btn-danger">Remove</button></td>
        </tr>`;
    tableBody.innerHTML += row;
  });
}

async function CreateLesson() {
  const lessonCode = document.getElementById("lessonCode").value;
  const name = document.getElementById("name").value;
  const classNumber = document.getElementById("class").value;
  const teacherName = document.getElementById("teacherName").value;
  const teacherSurname = document.getElementById("teacherSurname").value;
  const response = await fetch("https://localhost:7019/Lesson/Create", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      lessonCode,
      name,
      class: parseInt(classNumber),
      teacherName,
      teacherSurname,
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

async function UpdateLesson() {
  const lessonId = document.getElementById("lessonIdU").value;
  const lessonCode = document.getElementById("lessonCodeU").value;
  const name = document.getElementById("nameU").value;
  const classNumber = document.getElementById("classU").value;
  const teacherName = document.getElementById("teacherNameU").value;
  const teacherSurname = document.getElementById("teacherSurnameU").value;

  const response = await fetch(
    `https://localhost:7019/Lesson/Update?id=${lessonId}`,
    {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        lessonId,
        lessonCode,
        name,
        class: parseInt(classNumber),
        teacherName,
        teacherSurname,
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
  .getElementById("lesson-list")
  .addEventListener("click", async function (e) {
    if (e.target.classList.contains("lessonsIDs")) {

        //alert(e.target.classList);
      
        const response = await fetch(
        `https://localhost:7019/Lesson/UpdateView?id=${e.target.textContent}`
      );
      const lesson = await response.json();

      document.getElementById("lessonIdU").value = lesson.id;
      document.getElementById("lessonCodeU").value = lesson.lessonCode;
      document.getElementById("nameU").value = lesson.name;
      document.getElementById("classU").value = lesson.class;
      document.getElementById("teacherNameU").value = lesson.teacherName;
      document.getElementById("teacherSurnameU").value = lesson.teacherSurname;
    }
    
    if (e.target.classList.contains("removeLesson")) {
        let row = e.target.closest("tr");
        let lessonId = row.querySelector(".lessonsIDs").textContent.trim();
        if (confirm("Are You Sure???")) {
            await fetch(`https://localhost:7019/Lesson/Delete?id=${lessonId}`, {
                method: "DELETE"
            });
            row.remove();
        }
    }
  });

