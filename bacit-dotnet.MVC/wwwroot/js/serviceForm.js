// event to  "Send" button
document.getElementById("sendButton").addEventListener("click", function () {

    this.classList.add("animate-send");
    
    this.addEventListener("animationend", function () {
        this.classList.remove("animate-send");
    }, { once: true });
});
