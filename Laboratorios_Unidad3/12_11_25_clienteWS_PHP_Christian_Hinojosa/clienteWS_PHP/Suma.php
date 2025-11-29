<?php
    $clientephp = new SoapClient("http://localhost:56791/WebServices/WS_Server.asmx?WSDL");
    
    if (isset($_POST['n1'])) {

        //$params = ArrayObject();
        $params = new stdClass();
        $params->num1= $_POST['n1'];
        $params->num2 = $_POST['n2'];

        $num1 = $_POST['n1'];
        $num2 = $_POST['n2'];

        $Resultado = $clientephp->Suma($params)->SumaResult;
    }
?>
<html>
    <title>Suma de Web Services</title>
    <body>
        <center>
            <h1>Suma de Web Services</h1>
            <br>
            <br>
            <form name="frmSuma" action="" method="post">
                <label>Ingrese numero 1:</label>
                <input type="number" name="n1"/>
                <br>
                <label>Ingrese numero 2:</label>
                <input type="number" name="n2"/>
                <br><br>
                <input type="submit" name="Calcular" value="Calcular" />

                <br><br>
                <?php
                    if (isset($_POST['n1'])) {
                        echo "Numero 1: ".$num1."<br><br>";
                        echo "Numero 2: ".$num2."<br><br>";
                        echo "Resultado de la Suma: ".$Resultado;
                    }
                ?>
            </form>
        </center>
    </body>
</html>
