﻿Public Class HomeController
    Inherits BaseController

    '
    ' GET: /Home

    Function Index() As ActionResult
        Return View()
    End Function

    Function QuienesSomos() As ActionResult
        Return View()
    End Function

    Function Contacto() As ActionResult
        Return View()
    End Function

    Function PoliticaPrivacidad() As ActionResult
        Return View()
    End Function

    Function FAQ() As ActionResult
        Return View()
    End Function

    Function PaginaNoEncontrada() As ActionResult
        Return View()
    End Function

    Function Excepcion() As ActionResult
        Return View()
    End Function

End Class