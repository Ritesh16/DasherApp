function saveFile(file, data) {
    var link = document.createElement('a');
    link.download = file;
    link.href = "data:text/plain;charset=utf-8," + data;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}