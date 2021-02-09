CREATE TABLE public.clients
(
    id serial NOT NULL,
	name varchar(255) NOT NULL,
    CONSTRAINT "PK_clients" PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE public.clients
    OWNER to postgres;
	
	
CREATE TABLE public.clientaffected
(
    id serial NOT NULL,
    client_id integer NOT NULL,
    CONSTRAINT "PK_clientaffected" PRIMARY KEY (id),
    CONSTRAINT "FK_ClientAffected_Clients" FOREIGN KEY (client_id)
        REFERENCES public.clients (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE public.clientaffected
    OWNER to postgres;