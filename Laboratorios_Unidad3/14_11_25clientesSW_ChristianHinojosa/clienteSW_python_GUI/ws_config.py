from zeep import Client

# URL de tu WebService
WSDL_URL = "http://localhost:56791/WebServices/WS_Server.asmx?WSDL"

client = Client(wsdl=WSDL_URL)
