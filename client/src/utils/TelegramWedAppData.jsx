const TelegramWebAppData = () => {
  try {
    const urlHash = window.location.hash.substring(1);

    const urlParams = new URLSearchParams(urlHash);
    const tgWebAppData = urlParams.get("tgWebAppData");

    if (tgWebAppData) {
      const decodedData = decodeURIComponent(tgWebAppData);
      return JSON.parse(decodedData.split(".")[1].split("}")[0] + "}");
    }
  } catch (error) {
    console.error("Error parsing Telegram Web App data:", error);
  }
};

export default TelegramWebAppData;
