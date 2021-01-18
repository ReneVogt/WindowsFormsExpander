# Windows Forms Expander - Release notes

### Version 0.6.0 (2021/02/18)

Accessibility support (not tested, don't know how). Minor fixes and refactorings.

Issues:
- #5 Accessibility
- #6 is not easily pssible, dragging is not performed by our designer

### Version 0.5.0 (2021/02/15)

The first non-preview release. But the leading `0` in the version shows
that it's still initial development phase.  

Issues:  
- #1: There is still a little problem: the first child control may still
get `GotFocus` and `LostFocus` as well as `Enter` and `Leave` events while
`Expander` is trying hard to keep the focus away from the children while it
is collapsed.
- #4: Started documentation and project web site.


### Version 0.5.0-preview-4 (2021/01/15)

Minor fixes.

### Version 0.5.0-preview-3 (2021/01/14)

Minor fixes.

### Version 0.5.0-preview-2 (2021/01/14)

Suspended layout when control is collapsed.

### Version 0.5.0-preview-1 (2021/01/14)

This is the first shot, only published for testing purposes.

---
Ren&eacute; Vogt  
Dresden 2021/02/18