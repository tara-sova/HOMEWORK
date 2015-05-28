open System.ComponentModel

let mutable result = 0
          
type BackgroundWorkerForHundredStreams(i) =
    let array = Array.create 1000000 1
    let startPos = i * 10000
    let finishPos = (i + 1) * 10000 - 1
    
    let worker = new BackgroundWorker()
    let completed = new Event<_>()
    let error = new Event<_>()
    let cancelled = new Event<_>()          

    do worker.DoWork.Add(fun args -> 
                                     let rec count beginPos endPos  =
                                         if worker.CancellationPending then
                                            args.Cancel <- true
                                         elif (endPos - beginPos > 0) then
                                              result <- result + array.[beginPos]
                                              count (beginPos + 1) endPos
                                         else args.Result <- result   
                                     count startPos finishPos)

    do worker.RunWorkerCompleted.Add(fun args ->
                                                 if args.Cancelled then cancelled.Trigger()
                                                 elif args.Error <> null then error.Trigger args.Error
                                                 else completed.Trigger (args.Result :?> int))

    member b.WorkerCompleted = completed.Publish
    member b.WorkerCancelled = cancelled.Publish
    member b.WorkerError = error.Publish

    member b.RunWorkerAsync() = worker.RunWorkerAsync()
    member b.CancelAsync() = worker.CancelAsync()

let backgroundWorkers = [|for i in 0..100 - 1 -> new BackgroundWorkerForHundredStreams(i)|]
for i in 0..100 - 1 do backgroundWorkers.[i].RunWorkerAsync()
printfn "%A" result