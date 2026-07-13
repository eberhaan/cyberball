const urlParams = new URLSearchParams(window.location.search);


const participantID =
    urlParams.get("pid") || "TEST";


const condition =
    urlParams.get("condition") || "1";



console.log(
    "Participant:",
    participantID,
    "Condition:",
    condition
);
