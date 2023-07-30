using MixTelematics.Services;
using MixTelematics.Utilities;

CPUProcessHelper.IncreaseProcessPriorityToRealTime();
await ServiceRunner.Execute();

