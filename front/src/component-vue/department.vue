<template>
	<div class="row b-department">
		<div v-if="info" class="b-department__info">
			<h1>{{info.Name}}</h1>
		</div>
		<div v-if="info" class="b-department__directions">
			<h2>Специальности</h2>
			<section v-for="item in info.Directions">
				<article>
					<router-link :to="{ path: '/direction/' + item.Id}">{{item.Name}}</router-link>
				</article>
			</section>
		</div>
	</div>
</template>

<script>
	import axios from 'axios';

	export default {
		name: 'department',
		data() {
			return {
				info: null
			};
		},
		mounted() {
			axios
				.get('http://192.168.0.30:1488/api/departments/' + this.$route.params.id)
				.then(response => (this.info = response.data));
		}
	};
</script>
