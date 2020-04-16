"ProcessorCount: " + [System.Environment]::ProcessorCount

#Gets the amount of physical memory mapped to the process context.
"Current Process WorkingSet: " + [System.Environment]::WorkingSet

"Total Physical Memory: " + (systeminfo | Select-String 'Total Physical Memory:').ToString().Split(':')[1].Trim()