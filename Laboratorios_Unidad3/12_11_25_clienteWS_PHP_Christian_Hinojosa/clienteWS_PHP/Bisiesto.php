<?php
    $clientephp = new SoapClient("http://localhost:56791/WebServices/WS_Server.asmx?WSDL");
    
    if (isset($_POST['anio'])) {

        $params = new stdClass();
        $params->anio = $_POST['anio'];

        $anio = $_POST['anio'];

        // Llamar al método del Web Service
        $Resultado = $clientephp->AnioBisiesto($params)->AnioBisiestoResult;
    }
?>
<html>
    <title>Año Bisiesto Web Service</title>
    <body>
        <center>
            <h1>Año Bisiesto - Web Services</h1>
            <br><br>

            <form name="frmBisiesto" action="" method="post">
                <label>Ingrese un año:</label>
                <input type="number" name="anio" />
                <br><br>

                <input type="submit" name="Calcular" value="Calcular" />
                <br><br>

                <?php
                    if (isset($_POST['anio'])) {
                        echo "Año ingresado: " . $anio . "<br><br>";
                        echo "Resultado: " . $Resultado;
                    }
                ?>
            </form>
        </center>
    </body>
</html>
