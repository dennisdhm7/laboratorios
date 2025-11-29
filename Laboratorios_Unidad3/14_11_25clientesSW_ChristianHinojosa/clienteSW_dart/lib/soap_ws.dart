import 'package:http/http.dart' as http;

class SoapService {
  static const String url = "http://localhost:56791/WebServices/WS_Server.asmx";

  /// Envía una petición SOAP a tu servidor ASMX
  static Future<String> callSoap(String soapAction, String xml) async {
    final response = await http.post(
      Uri.parse(url),
      headers: {
        "Content-Type": "text/xml; charset=utf-8",
        "SOAPAction": soapAction,
      },
      body: xml,
    );

    if (response.statusCode == 200) {
      return response.body;
    } else {
      throw Exception("Error SOAP: ${response.statusCode}");
    }
  }
}
