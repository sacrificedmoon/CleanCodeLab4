describe('bug tracker app', () => {

    it('Open the app', () => {
        cy.visit('http://localhost:49164');
    })

    it('add a bug', () => {
        cy.get('[data-cy=Add-bug]').click()
        cy.get('[data-cy=bug-description]').type('I am a bug')
        cy.get('[data-cy=create-button]').click()
    }) 

    it('remove the bug', () => {
        cy.contains('I am a bug').parent('tr').within(() => {
            cy.get('td').eq(1).contains('Delete').click()
        })
        cy.get('[data-cy=delete-bug]').click()
    })
})


