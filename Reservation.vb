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
    End Structure
    Public ListeReservation As New List(Of Reservations)
    Public Function AjouterReservation(r As Reservations) As Boolean
        If r.places <= nbPlaceDisponible Then
            ListeReservation.Add(r)
            nbPlaceDisponible -= r.places
            MessageBox.Show("place disponible:" + CStr(nbPlaceDisponible), "reservation ajouté")
            Return True
        Else
            Return False
        End If
    End Function


End Module
