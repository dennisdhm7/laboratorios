<?php
    $clientephp = new SoapClient("http://localhost:56791/WebServices/WS_Server.asmx?WSDL");
    
    if (isset($_POST['n1'])) {

        $params = new stdClass();
        $params->numero = $_POST['n1'];

        $num1 = $_POST['n1'];

        $Resultado = $clientephp->Tabla1($params)->Tabla1Result;
    }
?>
<html>
    <title>Tabla de Multiplicar - Tabla1</title>
    <body>
        <center>
            <h1>Tabla de Multiplicar Tabla1 con Web Services</h1>
            <br><br>

            <form name="frmTabla" action="" method="post">
                <label>Ingrese un número:</label>
                <input type="number" name="n1" required />
                <br><br>

                <input type="submit" name="Calcular" value="Generar Tabla" />
                <br><br>

                <?php
                    if (isset($_POST['n1'])) {
                        echo "Número ingresado: ".$num1."<br><br>";
                        echo "<h3>Resultado:</h3>";

                        echo "<pre>".$Resultado."</pre>";
                    }
                ?>
            </form>
        </center>
    </body>
</html>
