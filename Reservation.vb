Module Reservation
    Dim nbPlaceDisponible As Integer = 50
    Public Structure Reservations
        Dim ligne As String
        Dim villeDepart As String
        Dim villeArrivee As String
        Dim h_debut As String
        Dim h_fin As String
        Dim places As Integer
        Dim Options As List(Of String)
        Dim type As String
        Public Sub InitReservation()
            Options = New List(Of String)
        End Sub
    End Structure
    Public ListeReservation As New List(Of Reservations)
    Public Function AjouterReservation(r As Reservations)
        If r.places <= nbPlaceDisponible Then
            ListeReservation.Add(r)
            nbPlaceDisponible -= r.places
            Return True
        Else
            Return False
        End If
    End Function


End Module
