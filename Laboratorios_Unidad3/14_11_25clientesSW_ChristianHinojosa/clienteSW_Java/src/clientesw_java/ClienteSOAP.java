package clientesw_java;

import java.io.*;
import java.net.HttpURLConnection;
import java.net.URL;

public class ClienteSOAP {

    private static final String URL_WS =
        "http://localhost:56791/WebServices/WS_Server.asmx";

    public static String enviarSOAP(String soapAction, String xml) throws Exception {

        URL url = new URL(URL_WS);
        HttpURLConnection con = (HttpURLConnection) url.openConnection();

        con.setRequestMethod("POST");
        con.setRequestProperty("Content-Type", "text/xml; charset=utf-8");
        con.setRequestProperty("SOAPAction", soapAction);
        con.setDoOutput(true);

        try (OutputStream os = con.getOutputStream()) {
            os.write(xml.getBytes("UTF-8"));
        }

        BufferedReader br = new BufferedReader(
                new InputStreamReader(con.getInputStream(), "UTF-8")
        );

        StringBuilder response = new StringBuilder();
        String line;

        while ((line = br.readLine()) != null) {
            response.append(line).append("\n");
        }

        return response.toString();
    }
}
