function sellay(num) {
    for (var id = 1; id <= 7; id++) {
        var bb = "ltitle" + id;
        if (id == num)
            document.getElementById(bb).className = "onlvse";
        else
            document.getElementById(bb).className = "onlvse1";
    }
    for (var id = 1; id <= 7; id++) {
        var ss = "tlist" + id;
        if (id == num)
            document.getElementById(ss).style.display = "block";
        else
            document.getElementById(ss).style.display = "none";
    }
}