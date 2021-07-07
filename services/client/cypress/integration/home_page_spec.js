describe('Main Page', () => {
  it('successfully loads', () => {
    cy.visit('/')
    cy.get('[data-cy=add-motion-picture-btn]')
      .should('exist');
  })

  it('cannot add motion picture', () => {
    cy.visit('/')
    cy.get('[data-cy=add-motion-picture-modal]')
      .children('[data-cy=add-motion-picture-btn]')
      .click()
      .then(($button) => {
        console.log($button);
      })
    cy.get('[data-cy=add-motion-picture-modal]')
      .find('[data-cy=name-input]')
      .type('Movie Name!')
    cy.get('[data-cy=add-motion-picture-modal]')
      .find('[data-cy=add-modal-submit-btn]')
      .should('have.class', 'disabled')
  })

  it('can add a motion picture', () => {
    cy.visit('/')
    cy.get('[data-cy=add-motion-picture-modal]')
      .children('[data-cy=add-motion-picture-btn]')
      .click()
      .then(($button) => {
        console.log($button);
      })
    cy.get('[data-cy=add-motion-picture-modal]')
      .find('[data-cy=name-input]')
      .type('Movie Name!')
    cy.get('[data-cy=add-motion-picture-modal]')
      .find('[data-cy=desc-input]')
      .type('Movie Description!')
    cy.get('[data-cy=add-motion-picture-modal]')
      .find('[data-cy=year-input]')
      .type('2012')
    cy.get('[data-cy=add-motion-picture-modal]')
      .find('[data-cy=add-modal-submit-btn]')
      .should('be.visible')
    cy.get('[data-cy=add-motion-picture-modal]')
      .find('[data-cy=add-modal-submit-btn]')
      .click()
    cy.get('[data-cy=toast-message]')
      .contains('Successfully Uploaded!')
  })
})
