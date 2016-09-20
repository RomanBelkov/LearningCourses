namespace HomeworkFs

type Medved() = 
    inherit HomeworkVb.Medved()

    override this.MeetMedved() =
        printfn "%s" (HomeworkCs.Medved.greet  + "F#")
        base.MeetMedved()