console.log("script.js has been loaded");
function showPurchaseAlert(adName, price, classroom, seller) {
    const message = `Congratulations on your purchase! \n\nItem: ${adName}\nPrice: ${price}\nClassroom: ${classroom}\nSeller: ${seller}`;
    alert(message);
}

