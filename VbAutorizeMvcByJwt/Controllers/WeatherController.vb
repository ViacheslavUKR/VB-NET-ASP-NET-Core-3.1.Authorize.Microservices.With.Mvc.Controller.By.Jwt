Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports Microsoft.AspNetCore.Authorization
Imports Microsoft.AspNetCore.Mvc

<Authorize(AuthenticationSchemes:="Bearer")>
<Route("api/[controller]")>
<ApiController>
Public Class WeatherController
    Inherits ControllerBase

    Private Shared ReadOnly Summaries As String() = {"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"}

    <HttpGet>
    Public Function GetForecastAsync(startDate As Date) As IWeatherForecastData()
        Dim rng = New Random()

        Dim Arr = Enumerable.Range(1, 5).Select(Function(index) New WeatherForecastData With {
            .Date = startDate.AddDays(index),
            .TemperatureC = rng.Next(-20, 55),
            .Summary = Summaries(rng.Next(Summaries.Length))
        }).ToArray()

        Return Arr
    End Function

End Class

