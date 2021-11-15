function showMessage(aElementName, aMessage) {
    document.getElementById(aElementName).innerText = aMessage;
}
function setFocusOnElement(aElementName) {
    aElementName.focus();
}
function ShowAlertMessage(aMessage) {
    alert(aMessage);
}

function FileSaveAs(filename, fileContent) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + encodeURIComponent(fileContent)
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

function openByteArray(DocFileName, ContentType, FileByte) {

    var blob = new Blob([base64ToArrayBuffer(FileByte)], { type: ContentType });
    var link = document.createElement('a');
    link.href = window.URL.createObjectURL(blob);
    link.download = DocFileName;
    window.open(link);
};
function base64ToArrayBuffer(base64) {
    var binaryString = window.atob(base64);
    var binaryLen = binaryString.length;
    var bytes = new Uint8Array(binaryLen);
    for (var i = 0; i < binaryLen; i++) {
        var ascii = binaryString.charCodeAt(i);
        bytes[i] = ascii;
    }
    return bytes;
}

function getOuterHTML(aElement) {
    return aElement.outerHTML;
}


function saveAsFile(filename, byteBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + byteBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

function OpenToIframe(iFrameId, byteBase64) {
    //Clear content
    document.getElementById(iFrameId).innerHTML = "";

    var ifrm = document.createElement('iframe');
    ifrm.setAttribute("src", "data:application/pdf;base64," + byteBase64);
    ifrm.style.width = "640px";
    ifrm.style.height = "480px";
    document.getElementById(iFrameId).appendChild(ifrm);
}

function OpenIntoNewTab(filename, byteBase64) {
    let pdfWindow = window.open("");
    pdfWindow.document.write(
        "<iframe width='100%' height='100%' src='data:application/pdf;base64, " + byteBase64 + "'></iframe>"
    );
    pdfWindow.document.title = filename;
}

function LoadPdfIntoSameTab(filename, byteBase64) {
    let pdfWindow = window.self;
    pdfWindow.document.write(
        "<iframe width='100%' height='100%' src='data:application/pdf;base64, " + byteBase64 + "'></iframe>"
    );
    pdfWindow.document.title = filename;
}

function PaymentCheckout(pOptions) {
    var options = {
        "key": pOptions.key,
        "amount": pOptions.amount,
        "currency": "INR",
        "name": pOptions.name,
        "order_id": pOptions.order_id,
        "handler": function (response) {
            window.open(pOptions.callback_url + response.razorpay_payment_id + "/" + response.razorpay_order_id + "/" + response.razorpay_signature, "_self");
        },
        "prefill": {
            "name": pOptions.prefill.name,
            "email": pOptions.prefill.email,
            "contact": pOptions.prefill.contact
        }
    };

    var rzp1 = new Razorpay(options);
    rzp1.open();
}