## Stage 1 - WPF / IoC / TDD

### Learning
- Basic WPF: https://www.pluralsight.com/courses/wpf-fundamentals
- WPF MVVM: https://app.pluralsight.com/library/courses/wpf-mvvm-in-depth/table-of-contents
- IoC and Frameworks: https://app.pluralsight.com/library/courses/inversion-of-control/table-of-contents
- Unity: https://msdn.microsoft.com/en-us/library/dn223671(v=pandp.30).aspx
- TDD (Do the entire 30 day course): http://www.telerik.com/blogs/30-days-tdd-day-one-what-is-tdd
- More TDD: https://app.pluralsight.com/library/courses/play-by-play-wilson-tdd/table-of-contents

### Tasks
- UI: Create a WPF application using the MVVM pattern for displaying the data in the “database” (a single file for now). Be able to modify the data displayed, and be able to save it. Also be able to add new items. If you are not familiar with WPF and MVVM, you can use Windows Form.
- Data: For the initial list of entities store the list of items in a single file. Use JSON for the serialization.
- Create a repository layer which hides the interactions with the file from the UI.