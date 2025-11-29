<?php
    $clientephp = new SoapClient("http://localhost:56791/WebServices/WS_Server.asmx?WSDL");
    $saludosWS = $clientephp->Saludos()->SaludosResult;
?>
<html>
    <title>Saludos de Web Services</title>
    <body>
        <center>
            <h1>Saludos de Web Services</h1>
            <br>
            <br>
            <?php
                echo $saludosWS;
            ?>
        </center>
    </body>
</html>
