let msgBox;
msgBoxStyle();
onReady();

function onReady() {
    msgBox = document.createElement("div");
    msgBox.id = "alertBox";

    document.body.appendChild(msgBox);
}

function msgBoxStyle() {
    let style = document.createElement("style");
    style.innerHTML = `
    #alertBox{
      display: none;
      position: fixed;
      left: 50%;
      top: 25px;
      transform: translateX(-50%);
      width: 200px;
      font-weight: bold;
      text-align: center;
      padding: 10px;
      border-radius: 5px;
      background: #f3f3f3;
      border-left-width: 5px;
      border-left-style: solid;
      z-index: 10;
      transition: all .5s ease-in;
    }`;
    document.head.appendChild(style);
}

function displayAlert(msg, isErr) {
    document.addEventListener("DOMContentLoaded", () => {
        if (isErr) {
            msgBox.style.borderColor = "#e63945";
        } else {
            msgBox.style.borderColor = "#4ecdc4";
        }
        msgBox.innerHTML = msg;
        msgBox.style.display = "block";
        setTimeout(() => {
            msgBox.style.display = "none";
        }, 3000);
    })
}







